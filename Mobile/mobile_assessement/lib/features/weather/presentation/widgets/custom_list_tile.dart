import 'package:flutter/material.dart';
import 'package:mobile_assessement/core/utils/colors.dart';
import 'package:mobile_assessement/core/utils/ui_converter.dart';

class CustomListTile extends StatelessWidget {
  const CustomListTile({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      width: UIConverter.getComponentWidth(context, 343),
      height: UIConverter.getComponentHeight(context, 76),
      decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(10), color: whiteColor),
      child: Row(
        children: [
          SizedBox(width: UIConverter.getComponentWidth(context, 10)),
          Text("Addis Ababa, Ethiopia", style: TextStyle(color: primaryTextColor,fontSize: 15,fontWeight: FontWeight.w500, fontFamily: "Roboto") ),
          // SizedBox(width: UIConverter.getComponentWidth(context, 100)),
          Spacer(),
          Text("20${String.fromCharCode(0x00B0)}", style: TextStyle(color: primaryColor,fontSize: 24,fontWeight: FontWeight.w500, fontFamily: "Roboto")),
          SizedBox(width: UIConverter.getComponentWidth(context, 30)),
          Icon(Icons.sunny,color: secondaryColor),
          SizedBox(width: UIConverter.getComponentWidth(context, 10)),

        ],
      ),
    );
  }
}
