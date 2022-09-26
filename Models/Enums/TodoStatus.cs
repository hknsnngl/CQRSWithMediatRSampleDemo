using System.ComponentModel;

namespace CQRSWithMediatRSampleDemo.Models.Enums;

public enum TodoStatus {
    [Description("İş Listesine Alındı")]
    JobList = 10,

    [Description("Çalışmaya Başlandı")]
    Starting = 20,

    [Description("Tamamlandı")]
    Done = 30,

    [Description("Tamamlanmadı")]
    NotDone = 40
}