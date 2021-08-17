import { WeekDay, WorkShopDayMode } from "@/core/utils/enums";
import { BaseEntity } from "./base.model";
import { WorkShop } from "./workshop.model";

export interface IWorkShopDay extends BaseEntity {
  weekday: WeekDay;
  mode: WorkShopDayMode;
  modeLocation: string;
  startHour: string;
  endHour: string | null;
  workShopId: number;
  workShop: WorkShop;
}