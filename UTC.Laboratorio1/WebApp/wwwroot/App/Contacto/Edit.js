"use strict";
var ContactoEdit;
(function (ContactoEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity
        },
        methods: {
            ClienteServicio: function (entity) {
                console.log(entity);
                if (entity.IdContacto == null) {
                    return App.AxiosProvider.ContactoGuardar(entity);
                }
                else {
                    return App.AxiosProvider.ContactoActualizar(entity);
                }
            },
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Guardando...");
                    this.ClienteServicio(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "El registro se inserto correctamente", icon: "success" })
                                .then(function () { return window.location.href = "Contacto/Grid"; });
                        }
                        else {
                            Toast.fire({ title: data.MsgError, icon: "error" });
                        }
                    });
                }
                else {
                    Toast.fire({ title: "Por favor complete los campos requeridos", icon: "error" });
                }
            }
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(ContactoEdit || (ContactoEdit = {}));
//# sourceMappingURL=Edit.js.map