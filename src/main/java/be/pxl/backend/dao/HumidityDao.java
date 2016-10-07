package be.pxl.backend.dao;

import be.pxl.backend.models.Humidity;
import be.pxl.backend.models.Temperature;

/**
 * Created by Jonas on 7/10/16.
 */
public interface HumidityDao {

    Humidity addHumidity(Humidity humidity);

}
