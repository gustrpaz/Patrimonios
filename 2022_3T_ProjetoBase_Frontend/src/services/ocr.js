import axios from "axios";

// método assincrono pois precisa do retorno da api
export const LerConteudoDaImagem = async (formData) => {

    let resultado;

    await axios({
        method: "POST",
        url: "https://brazilsouth.api.cognitive.microsoft.com/vision/v3.2/ocr?language=unk&detectOrientation=true&model-version=latest",
        data: formData,
        headers: {
            "Content-Type": "multipart/form-data",
            "Ocp-Apim-Subscription-Key": "e079b19bda1243348a82ad2c91e64065"
        }

    })
        .then(response => {
            console.log(response)
            resultado = LerJSON(response.data);
        })
        .catch(erro => console.log(erro))

    return resultado;

}

export const LerJSON = (obj) => {

    let resultado;

    obj.regions.forEach(regions => {
        regions.lines.forEach(lines => {
            lines.words.forEach(words => {
                if (words.text[0] === "1" && words.text[1] === "2") {
                    resultado = words.text;
                }

            });
        });
    });

    return resultado;

}

