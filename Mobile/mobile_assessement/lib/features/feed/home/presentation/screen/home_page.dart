
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import '../../../../../core/utils/style.dart';
import '../../../../../core/utils/ui_converter.dart';

import '../widgets/search_bar.dart';

class HomePage extends StatelessWidget {
  HomePage({super.key});
  List<String> FilterText = ["All", "Sports", "Tech", "Politics"];
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      floatingActionButtonLocation: FloatingActionButtonLocation.endFloat,
      appBar: AppBar(
        elevation: 0,
  
        
            
        title: Center(
            child: Text("Choose city!",
                style: myTextStyle.copyWith(
                    // color: blackColor,
                    fontSize: 25,
                    fontWeight: FontWeight.w800))),
        // actions: [ProfileAvatar()],
      ),
      body: Container(
        height: double.infinity,
        child: Column(
          children: [
            Searchbar(),
            Container(child: Text("My Fav Cities"),),
            ListView.builder(
        itemCount: 5,
        itemBuilder: (context, index) {
          return ListTile(
            title: Text('New Mexico'),
            subtitle: Text('USA'),
            trailing: Text('28°C'),
          );},),],),),);}}
