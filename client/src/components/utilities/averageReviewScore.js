export const calculateAverageReviewScore = (reviewArray) => {
  let totalScoreSum = 0;
  for (const r of reviewArray) {
    totalScoreSum += r.rating;
  }
  return totalScoreSum / reviewArray.length;
};
