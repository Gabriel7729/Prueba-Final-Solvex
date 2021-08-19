import { WeekDay, WorkShopDayMode } from "@/core/utils/enums";
import { BaseEntity } from "./base.model";
import { WorkShop } from "./workshop.model";

export class WorkShopDay extends BaseEntity {
  createdBy: string = '';
  day: WeekDay = WeekDay.MONDAY;
  mode: WorkShopDayMode = WorkShopDayMode.ON_SITE;
  modeLocation: string = '';
  startHour: Date | null = null;
  endHour?: Date | null = null;
  workShopId: number = 1;
  workShop?: WorkShop | null;
}