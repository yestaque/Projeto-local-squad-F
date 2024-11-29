// Obtém os elementos
const colorRange = document.getElementById("colorRange");
const moonIcon = document.getElementById("moonIcon");
const sunIcon = document.getElementById("sunIcon");
const body = document.body;

// Função para aplicar o tema com base no valor do range
function applyTheme(value) {
    // Ajusta a cor de fundo com base no valor do range (de 0 a 100)
    const backgroundColor = `rgb(${255 - value * 2.55}, ${255 - value * 2.55}, ${255 - value * 2.55})`;
    body.style.backgroundColor = backgroundColor;

    // Ajusta a cor dos ícones conforme o tema
    moonIcon.style.color = `rgb(${value * 2.55}, ${value * 2.55}, ${value * 2.55})`; // Lua clareia conforme o modo escuro
    sunIcon.style.color = `rgb(${255 - value * 2.55}, ${255 - value * 2.55}, 0)`; // Sol amarela conforme o modo claro
}

// Define a transição para a cor de fundo e dos ícones
body.style.transition = 'background-color 0.3s ease';
moonIcon.style.transition = 'color 0.3s ease';
sunIcon.style.transition = 'color 0.3s ease';

// Carrega o valor inicial do localStorage ou usa 100 como padrão
const initialValue = localStorage.getItem('colorRangeValue') || 100;
colorRange.value = initialValue;
applyTheme(initialValue);

// Event listener para atualizar o tema e salvar o valor no localStorage
colorRange.addEventListener("input", (event) => {
    const value = event.target.value;

    // Aplica o tema com o valor atual
    applyTheme(value);

    // Salva o valor no localStorage
    localStorage.setItem('colorRangeValue', value);
});
