public class Solution {
    public char[] dominoResultArr;

    public void FillResultArray(int startIndex, int endIndex, char v) {
        for(int i=startIndex; i<=endIndex; i++){
            dominoResultArr[i] = v;
        }
    }

    public void FindResultInSubset(int lastIndex, int currIndex, char lastVal, char currVal){
        if(lastVal == currVal){
            FillResultArray(lastIndex+1, currIndex, currVal);
        }
        else if (lastVal == 'L' && currVal == 'R') {
            FillResultArray(lastIndex+1, currIndex-1, '.');
            dominoResultArr[currIndex] = 'R';
        }
        else {
            double gapSize = currIndex - lastIndex;
            double midpoint = ((double) lastIndex) + (gapSize/2);

            for(int i=lastIndex+1; i<=currIndex; i++){
                if (i < midpoint) {
                    dominoResultArr[i] = 'R';
                }
                else if (i > midpoint) {

                    dominoResultArr[i] = 'L';
                }
                else {
                    dominoResultArr[i] = '.';
                }
            }
        }
    }

    public string PushDominoes(string dominoes) {
        dominoResultArr = new char[dominoes.Length];

        int lastIndex = -1;
        char lastVal = 'L';

        for (int i = 0; i<dominoes.Length; i++) {
            if (dominoes[i] != '.') {
                FindResultInSubset(lastIndex, i, lastVal, dominoes[i]);
                lastIndex = i;
                lastVal = dominoes[i];
            }
        }

        if (lastIndex < dominoes.Length - 1){
            if (lastVal == 'R') {
                FillResultArray(lastIndex+1, dominoes.Length - 1, 'R');
            }
            else {
                FillResultArray(lastIndex+1, dominoes.Length - 1, '.');
            }
        }

        return new String(dominoResultArr);
    }
}