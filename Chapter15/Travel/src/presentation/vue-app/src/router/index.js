import Vue from "vue";
import VueRouter from "vue-router";
import Home from "@/views/Main/Home";
import TourLists from "@/views/AdminDashboard/TourLists";
import TourPackages from "@/views/AdminDashboard/TourPackages";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home
  },
  /* lazy loading through dynamic import() */
  {
    path: "/about",
    name: "About",
    component: () => import("@/views/Main/About"),
  },
  {
    path: "/admin-dashboard",
    component: () => import("@/views/AdminDashboard"),
    children: [
      {
        path: "",
        component: () => import("@/views/AdminDashboard/DefaultContent"),
      },
      {
        path: "weather-forecast",
        component: () => import("@/views/AdminDashboard/WeatherForecast"),
      },
      /* eager loading through static import statement */
      {
        path: "tour-lists",
        component: TourLists,
      },
      {
        path: "tour-packages",
        component: TourPackages,
      }
    ],
  },
  {
    path: "*",
    redirect: "/",
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
