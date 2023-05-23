import 'package:flutter/material.dart';

class WeatherListPage extends StatefulWidget {
  @override
  _weatherListPage createState() => _weatherListPage();
}

class _weatherListPage extends State<WeatherListPage> {
  final List<String> items = List.generate(100, (i) => "Item $i");

  List<String> filteredItems = [];

  @override
  void initState() {
    super.initState();
    filteredItems.addAll(items);
  }

  void filterList(String query) {
    List<String> filtered = [];
    filtered.addAll(items);
    if (query.isNotEmpty) {
      filtered = filtered
          .where((item) => item.toLowerCase().contains(query.toLowerCase()))
          .toList();
    }
    setState(() {
      filteredItems.clear();
      filteredItems.addAll(filtered);
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: TextField(
          onChanged: (value) => filterList(value),
          decoration: InputDecoration(
            hintText: 'Search Cities',
          ),
        ),
      ),
      body: ListView.builder(
        itemCount: filteredItems.length,
        itemBuilder: (context, index) => ListTile(
          title: Text(filteredItems[index]),
        ),
      ),
    );
  }
}
