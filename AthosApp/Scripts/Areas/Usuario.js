$.UsuarioAPI = function () {
    return {

        Init: function () {
            this.Events.BindAll();
        },
        Events:
        {
            BindAll: function () {
                this.OnClickSalvarUsuario();
                this.OnClickAtualizarUsuario();
                this.OnClickDeleteUsuario();
            },
            OnClickSalvarUsuario: function () {
                $('#submitUser').off().on('click', function () {
                    
                    var nome = $('#nomeUsu').val()
                    var email = $('#emailUsu').val()
                    var idCondominio = -1;
                    var condominio = $('#condominioSelect option')
                    condominio.each(function () {
                        if (this.selected == true) {
                            idCondominio = this.value
                        }
                    });
                    var tipousuario = -1
                    var tipo = $('#divTipoUsu input')
                    tipo.each(function () {
                        if (this.checked) {
                            tipousuario = this.value
                        }
                    })
                    var data = JSON.stringify({ nomeUsuario: nome, email: email, condominio: idCondominio, tipoUsuario: parseInt(tipousuario) })

                    $.ajax({
                        url: '/Usuario/CriarUsuario',
                        contentType: 'application/json',
                        type: 'POST',
                        data: data,
                        success: function () {
                            Alert("Usuario cadastrado com sucesso")
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            Alert("Houve um erro ao cadastrar um Usuario")
                        }
                    });
                });
            },
            OnClickAtualizarUsuario: function () {
                $('#updateUser').off().on('click', function () {
                    debugger;
                    var id = $('#idUsu')
                    var nome = $('#nomeUsu').val()
                    var email = $('#emailUsu').val()
                    var idCondominio = -1;
                    var condominio = $('#condominioSelect option')
                    condominio.each(function () {
                        if (this.selected == true) {
                            idCondominio = this.value
                        }
                    });
                    var tipousuario = -1
                    var tipo = $('#divTipoUsu input')
                    tipo.each(function () {
                        if (this.checked) {
                            idresponsavel = this.value
                        }
                    })
                    $.ajax({
                        url: '/Usuario/Edit',
                        contentType: 'application/json',
                        type: 'POST',
                        data: JSON.stringify({ id: id, nomeUsuario: nome, email: email, condominio: idCondominio, tipoUsuario: tipoUsuario }),
                        success: function () {
                            Alert("Usuario cadastrado com sucesso")
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            Alert("Houve um erro ao cadastrar um Usuario")
                        }
                    });
                });
            },
            OnClickDeleteUsuario: function () {
                $('#removeCondo').off().on('click', function () {
                    var id = $('#idUSu')
                    $.ajax({
                        url: $.UsuarioAPI.urlDelete,
                        contentType: 'application/json',
                        type: 'POST',
                        data: JSON.stringify({ idUsu: id}),
                        success: function () {
                            Alert("Usuario excluido com sucesso")
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            Alert("Houve um erro ao excluir um Usuario")
                        }
                    });
                })
            },
        },
        Methods:
        {
            popularCondominios: function () {
                var condoDiv = $("#condominioSelect");
                $.ajax({
                    url: '/Condominio/ListarCondos',
                    contentType: 'application/json',
                    type: 'GET',
                    data: JSON.stringify({}),
                    success: function (data) {
                        var condos = $.parseJSON(data)
                        for (var i in condos) {
                            condoDiv.append($("<option />").val(condos[i].Id).text(condos[i].NomeCondominio));
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        Alert("Houve um erro ao buscar um Condominio")
                    }
                });
            },

            popularUsuarios: function () {
                var usuDiv = $("#divUsu");
                $.ajax({    
                    url: '/Usuario/ListarUsuarios',
                    contentType: 'application/json',
                    type: 'GET',
                    data: JSON.stringify({}),
                    success: function (data) {
                        debugger;
                        var users = $.parseJSON(data)
                        for (var i in users) {
                            usuDiv.append($("<div class='row'><div class='col-md-3'><a class='btn btn-block btn-default' href='/Usuario/Editar/" + users[i].Id + "'> Editar " + users[i].Nome + "</a></div><div class='col-md-3'><a class='btn btn-block btn-danger' href='/Usuario/Delete/" + users[i].Id + "'> Excluir " + users[i].Nome + "</a></div></div><br/>"));
                        }
                        //data.each(function () {
                        //    dropdown.append($("<option />").val(this.id).text(this.NomeAdministradora));
                        //});
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        Alert("Houve um erro ao buscar um Usuario")
                    }
                });
            },

            CarregarDados: function () {
                var idusu = parseInt(window.location.pathname.split("/")[3]);
                var data = JSON.stringify({ 'id': idusu });
                $.ajax({
                    url: '/Usuario/GetUsuario',
                    contentType: 'application/json',
                    type: 'POST',
                    data: data,
                    success: function (data) {
                        debugger;
                        var usuario = $.parseJSON(data)
                        $('#idUsu').val(usuario.Id)
                        $('#nomeUsu').val(usuario.Nome)
                        $('#emailUsu').val(usuario.Email)
                        var condominio = $('#condominioSelect option')
                        condominio.each(function () {
                            if (usuario.IdCondominio = this.value) {
                                this.selected = true
                            }
                        });
                        var tipo = $('#divTipoUsu input')
                        tipo.each(function () {
                            if (usuario.TipoUsuario = this.value)
                            {
                                this.checked = true; 
                            }
                        })
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        Alert("Houve um erro ao buscar um Usuario")
                    }
                });
            }
        }
    }
}