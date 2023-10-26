export const calculateAverageReviewScore = (reviewArray) => {
  let totalScoreSum = 0;
  if (reviewArray.length === 0) {
    return 0;
  } else {
    for (const r of reviewArray) {
      totalScoreSum += r.rating;
    }
    return totalScoreSum / reviewArray.length;
  }
};
