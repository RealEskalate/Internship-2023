import 'package:flutter/material.dart';
import '../../../../core/utils/ui_converter.dart';
import '../widgets/info.dart';
import '../widgets/nav.dart';

class Home extends StatelessWidget {
  Home({super.key});
  List<String> FilterText = ["For You", "Resources", "Scholarships", "Campus-Life"];


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(leading: Text("School-Hive"),
      actions: [Icon(Icons.search),Icon(Icons.notifications_none)],),
      body: Column(children: [ 
        Padding(
                padding: EdgeInsets.only(
                  top: UIConverter.getComponentHeight(context, 20),
                  right: UIConverter.getComponentWidth(context, 25),
                  left: UIConverter.getComponentWidth(context, 25),
                ),
                child: Row(
                    mainAxisAlignment: MainAxisAlignment.spaceAround,
                    children: [
                      for (var i = 0; i < FilterText.length; i++)
                        NavBar(
                            text: FilterText[i],
                            isActive: i == 0 ? true : false)
                    ])),
                    InfoCard(),
                    // 
                    ],
                    ),
        
    floatingActionButton: FloatingActionButton(onPressed: (){},
    shape: RoundedRectangleBorder(
    borderRadius: BorderRadius.all(Radius.circular(10.0)),
  ),

    ),


    );
  }
}