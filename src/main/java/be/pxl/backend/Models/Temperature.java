package be.pxl.backend.Models;

import java.util.Date;

/**
 * Created by Jonas on 7/10/16.
 */
public class Temperature {

    private int id;
    private float temperature;
    private Date date;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public float getTemperature() {
        return temperature;
    }

    public void setTemperature(float temperature) {
        this.temperature = temperature;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }



}
