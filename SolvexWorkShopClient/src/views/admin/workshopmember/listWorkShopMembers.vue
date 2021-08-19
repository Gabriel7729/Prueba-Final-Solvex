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
import { BTableColumnType, WorkShopMemberRole } from "@/core/utils/enums";
import { WorkShopMember } from "@/core/model";

@Component
export default class WorkShopMemberListComponent extends Mixins<
  SxBuefyTableMixin<WorkShopMember>
>(SxBuefyTableMixin, AuthMixin) {
  created() {
    this.setTableConfig();
    this.formatColumns();
  }
  setTableConfig() {
    this.tableConfig.controller = "workshopmember";
    this.tableConfig.aggregatable = true;
    this.tableConfig.aggregating.title = "Listado de los miembros de los WorkShops";
  }
  formatColumns() {
    let role = new BTableColumn("role", "Rol del miembro");
    role.type = BTableColumnType.Custom;
    role.customFilter = (value: WorkShopMemberRole) => Helpers.Filters.WorkShopMemberRole(value);

    this.tableConfig.insertColumns(role);
  }
}
</script>