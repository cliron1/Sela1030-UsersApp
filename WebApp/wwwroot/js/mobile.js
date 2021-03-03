$(function () {
	const url = 'http://localhost:54505/api/users';

	function getList() {
		const tbl = $('#table_rows');
		tbl.html('');

		$.get(url, function (data) {
			//console.log(data);
			//const ul = $('#users');
			
			$(data).each(function (index, item) {
				//const li = $('<li>');
				//li.text(`${item.id}. ${item.name}`);
				//ul.append(li);

				//tbl.append($('<tr>')
				//	.append($('<td>').text(item.id))
				//	.append($('<td>').text(item.name))
				//	.append($('<td>').append(
				//		$('<a>', { href: `?id=${item.id}` }).text('details')
				//	))
				//);

				const row = $(`<tr>
	<td>${item.id}</td>
	<td>${item.name}</td>
	<td><a href="?id=${item.id}">details1</a></td>
</tr>`);

				tbl.append(row);
			});
		});
	}
	getList();

	$('.btn-add').click(function () {
		//console.log('clicked');

		//debugger;

		let payload = { name: $('#name').val() }
		payload = JSON.stringify(payload);

		$.ajax({
			method: "POST",
			//dataType: "json",
			url: url,
			data: payload,
			contentType: "application/json; charset=utf-8"

		}).done(function (msg) {
			getList();

		}).fail(function (err) {
			console.log(err);
		});
	});
});
