document.getElementById("searchBtn").addEventListener("click", function() {
    const local = document.getElementById("local").value;
    const checkin = document.getElementById("checkin").value;
    const checkout = document.getElementById("checkout").value;

    if (local && checkin && checkout) {
        alert(`Procurando hotéis em ${local} de ${checkin} até ${checkout}.`);
    } else {
        alert("Por favor, preencha todos os campos.");
    }
});