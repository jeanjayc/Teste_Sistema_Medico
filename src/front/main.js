const crm = document.getElementById("crm");
const crmuf = document.getElementById("crmuf");



function loadDoc() {
    debugger;
    const xhttp = new XMLHttpRequest();
    xhttp.onload = function() {
        document.getElementById("name").innerHTML = this.responseText;
    }
    xhttp.open("POST", "https://localhost:44338/api/Doctor/api/Doctor/CreateDoctor");
    xhttp.send();
}

// function exibeNome() {
//     debugger;
//     const name = document.querySelector("#name").value;

//     if (name != "") {
//         alert(`"Olá" ${name}`);
//     }
// }