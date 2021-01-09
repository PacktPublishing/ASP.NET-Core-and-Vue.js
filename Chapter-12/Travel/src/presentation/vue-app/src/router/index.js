import Vue from "vue";
import VueRouter from "vue-router";
import Home from "@/views/Main/Home";
import DefaultContent from "@/views/AdminDashboard/DefaultContent";
import TourLists from "@/views/AdminDashboard/TourLists";
import TourPackages from "@/views/AdminDashboard/TourPackages";
import WeatherForecast from "@/views/AdminDashboard/WeatherForecast";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
    meta: {
      title: "Home",
    },
  },
  /* lazy loading -  component: () => import("...") */
  {
    path: "/about",
    name: "About",
    component: () => import("@/views/Main/About"),
    meta: {
      title: "About"
    },
  },
  {
    path: "/admin-dashboard",
    component: () => import("@/views/AdminDashboard"),
    meta: {
      title: "Admin Dashboard"
    },
    /* eager loading -  component: SamplePage */
    children: [
      {
        path: "",
        component: DefaultContent,
      },
      {
        path: "tour-lists",
        component: TourLists,
      },
      {
        path: "tour-packages",
        component: TourPackages,
      },
      {
        path: "weather-forecast",
        component: WeatherForecast,
      },
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
