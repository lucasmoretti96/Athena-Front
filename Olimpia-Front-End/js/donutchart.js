google.charts.load("current", { packages: ["corechart"] });
google.charts.setOnLoadCallback(drawChart);

function drawChart() {
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Disponível (GB)');
    data.addColumn('number', 'Usada (GB)');
    setInterval(() => {
        $.ajax({
            type: 'POST',
            url: "GraficoHD.aspx/getUltimaLeituraHD",
            dataType: 'json',
            contentType: 'application/json',
            data: '{}',
            success: function (response) {
                var str = response.d;
                var valores = str.split("@");
                var arrayvalores = [valores[0], parseInt(valores[1])];
                var disponivel = valores[0];
                var usado = valores[1];
                console.log(arrayvalores);

                data.addRow(["Disponível (GB)", Number(disponivel)]);
                data.addRow(["Usado (GB)", Number(usado)]);
                console.log(data);
                chart.draw(data, options);

                data.removeRow(1);
                data.removeRow(0);





            },
            error: function (jqXHR, exception) {
                console.log(jqXHR);
            }
        });
    }, 5000);

    var options = {
        titleTextStyle: {
            fontSize: 22, // 12, 18 whatever you want (don't specify px)
            bold: true,    // true or false
            italic: false  // true of false
        },
        title: 'Uso HD',
        pieHole: 0.4,
        slices: { 0: { color: '#cb8933' }, 1: { color: '#171719' } }
    };

    var chart = new google.visualization.PieChart(document.getElementById('donutchart'));
    chart.draw(data, options);
}