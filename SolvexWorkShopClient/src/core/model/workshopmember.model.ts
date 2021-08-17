import { WorkShopMemberRole } from "@/core/utils/enums";
import { BaseEntity } from "./base.model";
import { User } from "./user.model";
import { WorkShop } from "./workshop.model";

export interface IWorkShopMember extends BaseEntity {
  role: WorkShopMemberRole;
  workShopId: number;
  workShop: WorkShop;
  userId: number;
  user: User;
}