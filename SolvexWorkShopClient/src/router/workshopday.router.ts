import { RouteConfig } from "vue-router";
const item = {
  path: "/admin/workshopday",
  name:"WorkShopDay",
  component: () => import("../views/base.vue"),
  children: [
    {
      path: "",
      component: () => import("../views/admin/workshopday/listWorkShopDay.vue"),
    },
    {
      path: "add",
      component: () => import("../views/admin/workshopday/addWorkShopDay.vue")
    },
    {
        path: "edit/:id",
        component: () => import("../views/admin/workshopday/editWorkShopDay.vue")
      }
  ],
} as RouteConfig;

export default item;