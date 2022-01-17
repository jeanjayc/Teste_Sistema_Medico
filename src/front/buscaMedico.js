function buscaDados() {
    debugger;
    let xhr = new XMLHttpRequest;
    let url = "https://localhost:44338/api/Doctor/GetAllDoctor";
    xhr.open("GET", url, true);
    xhr.onreadystatechange = function() {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                preencheCampos(JSON.parse(xhr.responseText));
            }
        }
        xhr.send();
    }
}

function preencheCampos(json) {
    document.querySelector('#name').value = json.name;
    document.querySelector('#crm').value = json.crm;
    document.querySelector('#crmuf').value = json.crmuf;
}