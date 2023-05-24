import 'package:flutter/material.dart';

class EveryDay extends StatelessWidget {
  const EveryDay({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.fromLTRB(0, 15, 0, 0),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Text(
            "Mon,Nov 17",
            style: TextStyle(color: Colors.white),
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Text(
                "30",
                style: TextStyle(color: Colors.white),
              ),
              SizedBox(
                width: 10,
              ),
              Text(
                "20",
                style: TextStyle(color: Colors.white),
              ),
              SizedBox(
                width: 10,
              ),
              Icon(
                Icons.sunny,
                color: Colors.white,
              )
            ],
          )
        ],
      ),
    );
  }
}
