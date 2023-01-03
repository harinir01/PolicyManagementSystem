export type query = {
    fType: string;
    fValue: string;
};

// export function getQueryString(queryparams: query[]) {
//     let q = "";
//     queryparams.forEach(element => {
//         q += `${element.fType}=${element.fValue}&`;
//     });
//     return q;
// }