#!/usr/bin/env python3
from rpi_rf import RFDevice

rfdevice = RFDevice(22)
rfdevice.enable_tx()

rfdevice.tx_code(262236, 1, 326)
rfdevice.cleanup()