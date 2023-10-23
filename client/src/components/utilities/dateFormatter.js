export const dateFormatter = (date) => {
  const parsedDate = new Date(date);

  const day = parsedDate.getDate();
  const month = parsedDate.getMonth() + 1;
  const year = parsedDate.getFullYear(); 

  const formattedDate = `${month.toString().padStart(2, '0')}/${day
    .toString()
    .padStart(2, '0')}/${year}`;

  return formattedDate;
};
