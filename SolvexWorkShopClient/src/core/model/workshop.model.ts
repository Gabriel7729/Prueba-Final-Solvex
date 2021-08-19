import { WorkShopMemberRole } from "@/core/utils/enums";
import { BaseEntity } from "./base.model";
import { WorkShopDay } from "./workshopday.model";
import { WorkShopMember } from "./workshopmember.model";

export class WorkShop extends BaseEntity {
  name: string = '';
  description: string = '';
  startDate: Date | null | string = null;
  endDate?: Date | null | string = null;
  contentSupport: string = '';
  createdBy: string = 'Gabriel';
  //WorkShopDay
  days?: WorkShopDay;
  workShopDayId?: number | null;
  //WorkShopMember
  members?: WorkShopMember;
  role?: WorkShopMemberRole = WorkShopMemberRole.TEACHER;
  
}