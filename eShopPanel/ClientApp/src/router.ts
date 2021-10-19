import Vue from 'vue'

import Router from "vue-router";

import Main from '@/modules/main/main.vue';
import SignIn from '@/modules/sign-in/sign-in.vue';

Vue.use(Router);

const router = new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: [
        {
            path: '/panel',
            component: Main
        },
        {
            path: '/panel/sign-in',
            component: SignIn
        }
    ]
});

export default router;