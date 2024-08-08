package rs.assignments.basicapi;

import android.app.Application;
import android.content.Context;

import java.io.IOException;
import java.util.UUID;

public class RandomORGApp extends Application {

    public int[] GetRandomInteger(Context context, int n, int min, int max) {
        String apiKey = context.getString(R.string.api_key);
        org.random.api.RandomOrgClient roc = org.random.api.RandomOrgClient.getRandomOrgClient(apiKey);

        try {
            return roc.generateIntegers(n, min, max);
        } catch (IOException e) {
            return new int[0];
        }
    }

    public int[] GetRandomIntegerSequences(Context context, int n, int len, int min, int max) {
        String apiKey = context.getString(R.string.api_key);
        org.random.api.RandomOrgClient roc = org.random.api.RandomOrgClient.getRandomOrgClient(apiKey);

        try {
            int[][] res = roc.generateIntegerSequences(n, len, min, max);
            int[] ret = new int[n*len];
            for(int i = 0; i < n; i++) {
                if (len >= 0) System.arraycopy(res[i], 0, ret, i * n, len);
            }
            return ret;
        } catch (IOException e) {
            return new int[0];
        }
    }

    public double[] GetRandomDecimalFractions(Context context, int n, int decimalPlaces) {
        String apiKey = context.getString(R.string.api_key);
        org.random.api.RandomOrgClient roc = org.random.api.RandomOrgClient.getRandomOrgClient(apiKey);

        try {
            return roc.generateDecimalFractions(n, decimalPlaces);
        } catch (IOException e) {
            return new double[0];
        }
    }

    public double[] GetRandomGaussians(Context context, int n, double mean, double standardDeviation, int significantDigits) {
        String apiKey = context.getString(R.string.api_key);
        org.random.api.RandomOrgClient roc = org.random.api.RandomOrgClient.getRandomOrgClient(apiKey);

        try {
            return roc.generateGaussians(n, mean, standardDeviation, significantDigits);
        } catch (IOException e) {
            return new double[0];
        }
    }

    public String[] GetRandomStrings(Context context, int n, int len, String characters) {
        String apiKey = context.getString(R.string.api_key);
        org.random.api.RandomOrgClient roc = org.random.api.RandomOrgClient.getRandomOrgClient(apiKey);

        try {
            return roc.generateStrings(n, len, characters);
        } catch (IOException e) {
            return new String[0];
        }
    }

    public String[] GetRandomUUIDs(Context context, int n) {
        String apiKey = context.getString(R.string.api_key);
        org.random.api.RandomOrgClient roc = org.random.api.RandomOrgClient.getRandomOrgClient(apiKey);

        try {
            UUID[] uuids = roc.generateUUIDs(n);
            String[] strs = new String[uuids.length];
            for (int i = 0; i < uuids.length; i++) {
                strs[i] = uuids[i].toString();
            }
            return strs;
        } catch (IOException e) {
            return new String[0];
        }
    }

    public String[] GetRandomBlobs(Context context, int n, int size) {
        String apiKey = context.getString(R.string.api_key);
        org.random.api.RandomOrgClient roc = org.random.api.RandomOrgClient.getRandomOrgClient(apiKey);

        try {
            return roc.generateBlobs(n, size);
        } catch (IOException e) {
            return new String[0];
        }
    }
}
