<template>
  <div>

    <sx-buefy-table :config="tableConfig">
      <template v-slot:name="{ row }">
        <div class="media">
          <div class="media-left">
            <p class="icon-image-rounded has-background-primary">WS</p>
          </div>
          <div class="media-content">
            <p class="title is-6">
              <b-tooltip label="Perfil no disponible">
                <a class="has-text-link cursor-ban">{{ row.name }}</a>
              </b-tooltip>
            </p>
            <p class="subtitle is-6">@{{ row.createdBy }}</p>
          </div>
        </div>
      </template>
    </sx-buefy-table>

  </div>
</template>
<script lang="ts">
import { Component, Mixins } from "vue-property-decorator";
import { AuthMixin, SxBuefyTableMixin } from "@/mixins";
import { BTableColumn } from "@/components/sx/sx-buefy-table/config";
import Helpers from "@/core/utils/helpers";
import { BTableColumnType } from "@/core/utils/enums";
import { WorkShop } from "@/core/model";

@Component
export default class WorkShopListComponent extends Mixins<
  SxBuefyTableMixin<WorkShop>
>(SxBuefyTableMixin, AuthMixin) {
  created() {
    this.setTableConfig();
    this.formatColumns();
  }
  setTableConfig() {
    this.tableConfig.controller = "WorkShop";
    this.tableConfig.aggregatable = true;
    this.tableConfig.aggregating.title = "Listado de WorkShops";
  }
  formatColumns() {
    let name = new BTableColumn("name", "Nombre_WorkShop");
    name.sortable = false;
    name.customTemplate = true;

    let description = new BTableColumn("description", "Descripción");
    description.customTemplate = false;

    let startDate = new BTableColumn("startDate", "Fecha de inicio");
    startDate.customTemplate = false;
    startDate.type = BTableColumnType.Date;

    let endDate = new BTableColumn("endDate", "Fecha de fin");
    endDate.customTemplate = false;
    endDate.type = BTableColumnType.Date;

    let contentSupport = new BTableColumn("contentSupport", "Contenido de apoyo");
    contentSupport.customTemplate = false;

    this.tableConfig.insertColumns(name, description, startDate, endDate, contentSupport);
  }
}
</script>

