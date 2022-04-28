
namespace App.AxiosProvider   {

    //export const ContactoEliminar = (id) => axios.delete<DBEntity>("Contacto/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);
    //export const ContactoGuardar= (entity) => axios.post<DBEntity>("Contacto/Edit", entity).then(({ data }) => data);

    export const ContactoEliminar = (id) => ServiceApi.delete<DBEntity>("api/Contacto/" + id).then(({ data }) => data);
    export const ContactoGuardar = (entity) => ServiceApi.post<DBEntity>("api/Contacto", entity).then(({ data }) => data);
    export const ContactoActualizar = (entity) => ServiceApi.put<DBEntity>("api/Contacto", entity).then(({ data }) => data);


    export const Login = (entity) => axios.post<DBEntity>("Login", entity).then(({ data }) => data);
    export const UsuarioRegistrar = (entity) => axios.post<DBEntity>("Registrarse",entity).then(({ data }) => data);
}




