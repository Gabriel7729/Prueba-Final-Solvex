import { WorkShopMemberRole } from "@/core/utils/enums";
import { BaseEntity } from "./base.model";
import { User } from "./user.model";
import { WorkShop } from "./workshop.model";

export class WorkShopMember extends BaseEntity {
  role: WorkShopMemberRole = WorkShopMemberRole.STUDENT;
  workShopId: number | null = null;
  workShop?: WorkShop;
  userId: number | null = null;;
  user?: User;
}