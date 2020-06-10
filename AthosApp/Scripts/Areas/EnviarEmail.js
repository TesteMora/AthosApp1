$.EnvioAPI = function () {
    return {

        Init: function () {
            this.Events.BindAll();

        },
        Events:
        {
            BindAll: function () {
                this.OnClickEnviarEmail();
            },

            OnClickEnviarEmail: function () {
                $('#enviarEmail').off().on('click', function () {
                    debugger;
                    var mensagem = $('#corpo')[0].value
                    var assuntos = $('#selectAssunto option')
                    var idAssunto = -1
                    assuntos.each(function () {
                        if (this.selected == true) {
                            idAssunto = this.value
                        }
                    })
                    var usuarios = $('#selectUser option')
                    var idUsuario = -1
                    usuarios.each(function () {
                        if (this.selected == true) {
                            idUsuario = this.value
                        }
                    })
                    var data = JSON.stringify({ idAssunto: parseInt(idAssunto), idUsuario: parseInt(idUsuario), corpoEmail: mensagem})

                    $.ajax({
                        url: '/Envio/Enviar',
                        contentType: 'application/json',
                        type: 'POST',
                        data: data,
                        success: function () {
                            alert("Email Enviado com sucesso!")
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert("Erro ao enviar Email!")
                        }
                    });
                });
            },
           
        },
        Methods:
        {

            popularDropdownEmails: function () {
                var dropdown = $("#selectUser");
                $.ajax({
                    url: '/Usuario/ListarUsuarios',
                    contentType: 'application/json',
                    type: 'GET',
                    data: JSON.stringify({}),

                    success: function (data) {
                        var users = $.parseJSON(data)
                        for (var i in users) {
                            if(users[i].TipoUsuario == 1)
                                dropdown.append($("<option />").val(users[i].Id).text(users[i].Email));
                        }
                        var dropdownAssunto = $("#selectAssunto");
                        $.ajax({
                            url: '/Assunto/ListarAssuntos',
                            contentType: 'application/json',
                            type: 'GET',
                            data: JSON.stringify({}),

                            success: function (data) {
                                var assuntos = $.parseJSON(data)
                                for (var i in assuntos) {
                                    if (assuntos[i].TipoAssunto == 1)
                                        dropdownAssunto.append($("<option />").val(assuntos[i].Id).text("Administrativo"));
                                    else
                                        dropdownAssunto.append($("<option />").val(assuntos[i].Id).text("Condominal"));

                                }
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert("Houve um erro ao buscar Assuntos")
                            }
                        });
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Houve um erro ao buscar usuarios")
                    }
                });
            },

            popularDropdownAssuntos: function () {
               
            },
            
        }
    }
}