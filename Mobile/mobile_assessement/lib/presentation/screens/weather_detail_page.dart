import 'package:flutter/material.dart';
import 'package:mobile_assessement/presentation/widgets/broadcast_card.dart';


import '../../../../core/utils/colors.dart';

class WeatherDetailPage extends StatelessWidget{
  @override
  Widget build(BuildContext context) {
    final screenHeight = MediaQuery.of(context).size.height;
    final screenWidth =  MediaQuery.of(context).size.width;
    final textSize =  MediaQuery.textScaleFactorOf(context);
    return SafeArea(
      child: Scaffold(
        body:SingleChildScrollView(child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [Container(
          
          width: screenWidth * 1,
          height:  screenHeight * 0.4,
          child:Column(
    
            children: [
          Row(
            children: [
              Padding(
                padding:  EdgeInsets.only(left: 0.3* screenWidth,top:screenHeight * 0.05,bottom: screenHeight * 0.01),
                child: Text("New Mexico",style: TextStyle(fontSize: 21 * textSize,fontWeight:FontWeight.w100),),
              ),
              Padding(
                padding:  EdgeInsets.only(top:screenHeight * 0.05,left : 0.3 * screenWidth),
                child: Icon(Icons.favorite_border,color:  Colors.red,),
              )
            ],
          ),Padding(
            padding:  EdgeInsets.only(bottom: screenHeight * 0.08),
            child: Text("date"),
          ),Container(
            width: screenWidth * 0.3,
            height:  screenHeight * 0.2,
            child: Image.network("https://thumbs.dreamstime.com/b/d-rendering-sun-covered-clouds-icon-render-cloudy-weather-268222674.jpg"))]
          ),),

          Padding(
            padding:  EdgeInsets.only(left:screenWidth * 0.09 ),
            child: Text("Mostly Sunny",style: TextStyle(fontSize: 18 * textSize,fontWeight: FontWeight.w500,color:Color.fromRGBO(159, 147, 255, 1)
),),
          ),
         Padding(
           padding:EdgeInsets.only(left:screenWidth * 0.09 ,bottom: screenHeight * 0.04),
           child: Text("30"+   '\u00b0',style: TextStyle(fontSize: 40* textSize,fontWeight: FontWeight.w500,color:Color.fromRGBO(33, 23, 114, 1))),
         ),
        
        BroadCastCard()

        ],)),
             ));
           
}
}