const edits = document.getElementsByClassName('edit-fruit')
const cancelEdits = document.getElementsByClassName('cancel-edit-fruit')

for (let edit of edits) {
    edit.addEventListener('click', e => changeToEditMode(e))
}

for (let cancelEdit of cancelEdits) {
    cancelEdit.addEventListener('click', e => changeToNormalMode(e))
}

function changeToEditMode(event) {
    let fruitId = event.currentTarget.dataset.id

    const editedFruits = document.querySelectorAll(`tr[data-id="${fruitId}"]`)

    editedFruits[0].classList.add('d-none')
    editedFruits[1].classList.remove('d-none')
}

function changeToNormalMode(event) {
    let fruitId = event.currentTarget.dataset.id

    const editedFruits = document.querySelectorAll(`tr[data-id="${fruitId}"]`)

    editedFruits[0].classList.remove('d-none')
    editedFruits[1].classList.add('d-none')

    const form = editedFruits[1].querySelector('form')
    form.reset()
}