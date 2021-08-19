<template>
  <div>

    <sx-buefy-table :config="tableConfig">
      <!-- <template v-slot:startHour="{ row }">
        <div class="media">
          <div class="media-left">
            <p class="icon-image-rounded has-background-primary">WS</p>
          </div>
          <div class="media-content">
            <p class="title is-6">
              <b-tooltip label="Perfil no disponible">
                <a class="has-text-link cursor-ban">{{ row }}</a>
              </b-tooltip>
            </p>
            <p class="subtitle is-6">@{{ row.createdBy }}</p>
          </div>
        </div>
      </template> -->
    </sx-buefy-table>

  </div>
</template>
<script lang="ts">
import { Component, Mixins } from "vue-property-decorator";
import { AuthMixin, SxBuefyTableMixin } from "@/mixins";
import { BTableColumn } from "@/components/sx/sx-buefy-table/config";
import Helpers from "@/core/utils/helpers";
import { BTableColumnType, WeekDay, WorkShopDayMode } from "@/core/utils/enums";
import { WorkShopDay } from "@/core/model/workshopday.model";

@Component
export default class WorkShopDayListComponent extends Mixins<
  SxBuefyTableMixin<WorkShopDay>
>(SxBuefyTableMixin, AuthMixin) {
  created() {
    this.setTableConfig();
    this.formatColumns();
  }
  setTableConfig() {
    this.tableConfig.controller = "WorkShopDay";
    this.tableConfig.aggregatable = true;
    this.tableConfig.aggregating.title = "Listado de WorkShopDays";
  }
  formatColumns() {
    let day = new BTableColumn("day", "Día");
    day.type = BTableColumnType.Custom;
    day.customFilter = (value: WeekDay) => Helpers.Filters.WeekDay(value);

    let mode = new BTableColumn("mode", "Modo del WorkShop");
    mode.type = BTableColumnType.Custom;
    mode.customFilter = (value: WorkShopDayMode) => Helpers.Filters.WorkShopDayMode(value);

    let modeLocation = new BTableColumn("modeLocation", "Modo Ubicación");
    modeLocation.customTemplate = false;

    let startHour = new BTableColumn("startHour", "Hora de inicio");
    startHour.customTemplate = false;
    startHour.type = BTableColumnType.Time;

    let endHour = new BTableColumn("endHour", "Hora de fin");
    endHour.customTemplate = false;
    endHour.type = BTableColumnType.Time;

    this.tableConfig.insertColumns(day, mode, modeLocation, startHour, endHour);
  }
}
</script>