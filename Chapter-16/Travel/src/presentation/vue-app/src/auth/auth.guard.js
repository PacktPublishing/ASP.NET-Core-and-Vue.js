import store from "@/store";

export const authGuard = (to, from, next) => {
  console.log("authGuard");
  const authRequired = to.matched.some((record) => record.meta.requiresAuth);

  if (authRequired) {
    if (store.getters["authModule/isAuthenticated"]) {
      next();
      return;
    }

    next("/login");
  }

  next();
};
