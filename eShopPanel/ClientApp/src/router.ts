import Router from "vue-router";

import SignIn from '@/modules/sign-in/sign-in.vue';

const router = new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: [
        {
            path: '/panel/sign-in',
            component: SignIn
        }
    ]
});

export default router;