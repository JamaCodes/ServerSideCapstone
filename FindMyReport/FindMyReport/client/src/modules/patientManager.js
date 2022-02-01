const baseUrl = "/api/patient";

export const getAllPatients = () => {
    return fetch(baseUrl).then((res) => res.json());
};