package be.pxl.backend.models;

import javax.persistence.*;
import java.util.Date;

/**
 * Created by Jonas on 7/10/16.
 */
@Entity
@Table(name = "AcceleroMeters")
public class AcceleroMeter {

    @Id
    @GeneratedValue
    @Column(name = "Id")
    private int id;

    @Column(name = "X")
    private float x;
    @Column(name = "Y")
    private float y;
    @Column(name = "Z")
    private float z;

    @Temporal(TemporalType.TIMESTAMP)
    @Column(name = "Date")
    private Date date;

    public int getId() {
        return id;
    }

    public float getX() {
        return x;
    }

    public void setX(float x) {
        this.x = x;
    }

    public float getY() {
        return y;
    }

    public void setY(float y) {
        this.y = y;
    }

    public float getZ() {
        return z;
    }

    public void setZ(float z) {
        this.z = z;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }
}
