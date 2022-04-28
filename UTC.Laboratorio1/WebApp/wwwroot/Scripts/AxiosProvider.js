"use strict";
var App;
(function (App) {
    var AxiosProvider;
    (function (AxiosProvider) {
        //export const ContactoEliminar = (id) => axios.delete<DBEntity>("Contacto/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);
        //export const ContactoGuardar= (entity) => axios.post<DBEntity>("Contacto/Edit", entity).then(({ data }) => data);
        AxiosProvider.ContactoEliminar = function (id) { return ServiceApi.delete("api/Contacto/" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ContactoGuardar = function (entity) { return ServiceApi.post("api/Contacto", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ContactoActualizar = function (entity) { return ServiceApi.put("api/Contacto", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.Login = function (entity) { return axios.post("Login", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.UsuarioRegistrar = function (entity) { return axios.post("Registrarse", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
    })(AxiosProvider = App.AxiosProvider || (App.AxiosProvider = {}));
})(App || (App = {}));
//# sourceMappingURL=AxiosProvider.js.map