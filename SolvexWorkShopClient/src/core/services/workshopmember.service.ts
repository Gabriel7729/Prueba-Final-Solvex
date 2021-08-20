import axios, { AxiosResponse } from "axios";
import { BaseService, IBaseService } from "./base.service";
import { ChangePassword, User, WorkShopMember } from "../model";
import { IEntityOperationResult } from "../infraestructure/abstract";

export interface IWorkShopMember extends IBaseService<WorkShopMember> {

}

export class WorkShopMemberService extends BaseService<WorkShopMember> implements IWorkShopMember {

    constructor(controller: string) {
        super(controller)
    }

}