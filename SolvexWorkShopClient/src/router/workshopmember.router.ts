import { RouteConfig } from "vue-router";
const item = {
  path: "/admin/workshopmember",
  name: "WorkShopMembers",
  component: () => import("../views/base.vue"),
  children: [
    {
      path: "",
      component: () => import("../views/admin/workshopmember/listWorkShopMembers.vue"),
    },
    {
      path: "add/:id",
      component: () => import("../views/admin/workshopmember/addWorkShopMember.vue")
    },
    {
      path: "edit/:id",
      component: () => import("../views/admin/workshopmember/editWorkShopMember.vue")
    }
  ],
} as RouteConfig;

export default item;