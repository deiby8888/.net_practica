document.addEventListener("DOMContentLoaded", () => {
    insertAutors()
})

async function insertAutors() {
    const select = document.querySelector("#selectAutor")

    const response = await fetch('/CrudController1/ListarAutors')
    const data = await response.json()
    console.log(data)

    data.forEach(autor => {
        const option = document.createElement("option")
        option.value = autor.id_user
        option.textContent = autor.userName
        select.appendChild(option)
    })

}


