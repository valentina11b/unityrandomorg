package rs.assignments.basicapi;
import android.app.Application;
import android.content.Context;

import java.io.IOException;

public class RandomORGApp extends Application {

    private final String apiKey = getString(R.string.api_key);

    public float GetRandomInteger(Context context) {
        try {
            org.random.api.RandomOrgClient roc = org.random.api.RandomOrgClient.getRandomOrgClient(apiKey);
            int[] randoms = roc.generateIntegers(5, 0, 10);
            return randoms[0];
        } catch (IOException e) {
            return -1;

        }
    }
}
