//*****************************************************************************
//** 3085. Minimum Deletions to Make String K-Special               leetcode **
//*****************************************************************************

int cmp(const void *a, const void *b)
{
    return (*(int *)a - *(int *)b);
}

int minimumDeletions(char *word, int k)
{
    int freq[26] = {0};
    int len = strlen(word);

    for (int i = 0; i < len; i++)
    {
        freq[word[i] - 'a']++;
    }

    // Create nums array with only non-zero frequencies
    int nums[26];
    int numsSize = 0;

    for (int i = 0; i < 26; i++)
    {
        if (freq[i] > 0)
        {
            nums[numsSize++] = freq[i];
        }
    }

    int retval = len;

    for (int v = 0; v <= len; v++)
    {
        int deletions = 0;
        for (int i = 0; i < numsSize; i++)
        {
            if (nums[i] < v)
            {
                deletions += nums[i];
            }
            else if (nums[i] > v + k)
            {
                deletions += nums[i] - v - k;
            }
        }
        if (deletions < retval)
        {
            retval = deletions;
        }
    }

    return retval;
}