package application.data.model;

import lombok.*;
import lombok.experimental.FieldDefaults;

import javax.persistence.*;
import javax.validation.constraints.Min;
import java.sql.Timestamp;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.LocalTime;

@Entity
@Data
@FieldDefaults(level = AccessLevel.PRIVATE)
@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
public class Voyage {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    Long id;

    @ManyToOne
    @JoinColumn(name = "from_id")
    Airport from;

    @Column
    LocalDate fromDate;
    @Column
    LocalTime fromTime;

    @ManyToOne
    @JoinColumn(name = "to_id")
    Airport to;

    @Column
    LocalDate toDate;
    @Column
    LocalTime toTime;

    boolean baggagePassed;

    @Min(value = 0)
    Long price;

    @PrePersist
    public void toCreate() {
        setBaggagePassed(false);
    }
}
