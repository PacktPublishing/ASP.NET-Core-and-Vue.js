import Vue from "vue";
import VueRouter from "vue-router";
import Home from "@/views/Main/Home";
import TourLists from "@/views/AdminDashboard/TourLists";
import TourPackages from "@/views/AdminDashboard/TourPackages";
import { authGuard } from "@/auth/auth.guard";
import { isTokenFromLocalStorageValid } from "@/auth/auth.service";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
    meta: {
      requiresAuth: false
    }
  },
  /* lazy loading through dynamic import() */
  {
    path: "/about",
    name: "About",
    component: () => import("@/views/Main/About"),
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/admin-dashboard",
    component: () => import("@/views/AdminDashboard"),
    meta: {
      requiresAuth: true
    },
    children: [
      {
        path: "",
        component: () => import("@/views/AdminDashboard/DefaultContent")
      },
      {
        path: "weather-forecast",
        component: () => import("@/views/AdminDashboard/WeatherForecast")
      },
      /* eager loading through static import statement */
      {
        path: "tour-lists",
        component: TourLists
      },
      {
        path: "tour-packages",
        component: TourPackages
      }
    ]
  },
  {
    path: "/login",
    component: () => import("@/auth/views/Login"),
    meta: {
      requiresAuth: false
    },
    beforeEnter: (to, from, next) => {
      const valid = isTokenFromLocalStorageValid();
      console.log("VALID::", valid);
      if (valid) {
        next("/continue-as");
      } else {
        next();
      }
    }
  },
  {
    path: "/continue-as",
    component: () => import("@/auth/views/ContinueAs"),
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/logout",
    beforeEnter() {
      localStorage.clear();
      window.location.href = "/";
    }
  },
  {
    path: "*",
    redirect: "/"
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});

router.beforeEach((to, from, next) => {
  console.log("router.beforeEach");
  authGuard(to, from, next);
});

export default router;
