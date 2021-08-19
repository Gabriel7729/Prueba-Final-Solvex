import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Home from '../views/Home.vue'
import User from './user.router'
import WorkShops from './workshop.router'
import WorkShopDay from './workshopday.router'
import WorkShopMembers from './workshopmember.router'


Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'Home',
    component: Home,
  },
  {
    path: '/myworkshops',
    name: 'myworkshops',
    component: () => import('../views/myWorkShops.vue')
  },
  User,
  WorkShops,
  WorkShopDay,
  WorkShopMembers
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
