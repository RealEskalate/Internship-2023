import 'package:flutter/material.dart';

class UpperBar extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Container(
      height: 60, // Adjust the height according to your needs
      // color: Colors.grey[200], // Background color
      padding: EdgeInsets.symmetric(horizontal: 16), // Horizontal padding
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          // Text on the left side
          Text(
            'School-Hive',
            style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
          ),
          // Two icons on the right side
          Row(
            children: [
              Icon(Icons.search),
              SizedBox(width: 10), // Adjust the spacing between icons if needed
              Icon(Icons.notifications_active),
            ],
          ),
        ],
      ),
    );
  }
}
