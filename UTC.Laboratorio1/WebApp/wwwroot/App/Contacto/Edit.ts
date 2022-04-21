namespace ContactoEdit {

    var Entity = $("#AppEdit").data("entity")

    var Formulario = new Vue(
        {
            data:
            {
                Formulario: "#FormEdit",
                Entity: Entity
            },

            methods: {

                ClienteServicio(entity) {
                    console.log(entity);
                    if (entity.IdContacto == null) {
                        return App.AxiosProvider.ContactoGuardar(entity);

                    } else {
                        return App.AxiosProvider.ContactoActualizar(entity);

                    }
                },

                Save() {
                    

                    if (BValidateData(this.Formulario)) {
                        Loading.fire("Guardando...");


                        this.ClienteServicio(this.Entity).then(data => {
                            Loading.close();

                       

                            if (data.CodeError == 0) {

                                Toast.fire({ title: "El registro se inserto correctamente", icon: "success" })
                                    .then(() => window.location.href = "Contacto/Grid");

                            } else {
                                Toast.fire({ title: data.MsgError, icon: "error" });
                            }

                        });

                    }
                    else {
                        Toast.fire({ title: "Por favor complete los campos requeridos", icon: "error" });
                    }
                }
            },

            mounted() {
                CreateValidator(this.Formulario);
            }

        }
    );

    Formulario.$mount("#AppEdit");

    }