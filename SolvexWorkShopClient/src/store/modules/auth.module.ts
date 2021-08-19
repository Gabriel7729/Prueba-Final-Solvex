
import { User } from "@/core/model";
import { UserRole } from "@/core/utils/enums";
import { Module } from "vuex";

const authModule: Module<any, any> = {
    state: {
        user: {
            id:2,
            name: 'Gabriel',
            lastName: 'De La Rosa',
            userName: 'admin',
            userRole: UserRole.ADMIN
        } as User,
    },
    getters: {
        isCurrentUserAdmin(state) {
            return state.user.userRole === UserRole.ADMIN;
        }
    },
    mutations: {

    },
    actions: {
    }
};

export default authModule;