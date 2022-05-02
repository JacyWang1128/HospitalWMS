﻿using HospitalWMS.Client.Controls.Manager.Apply;
using HospitalWMS.Client.Controls.Manager.ExWarehouse;
using HospitalWMS.Client.Controls.Manager.Goods;
using HospitalWMS.Client.Controls.Manager.ImWarehouse;
using HospitalWMS.Client.Controls.Manager.Purchase;
using HospitalWMS.Client.Controls.Manager.Restitution;
using HospitalWMS.Client.Controls.Manager.Supplier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalWMS.Client.Controls.Manager
{
    public partial class ManageMainControl : UserControl
    {
        private SupplierManageControl _supplierManageControl = null;
        private SpecificationManageControl _specificationManageControl = null;
        private GoodsManagerControl _goodsManageControl = null;
        private ApplyImWarehouseControl _applyImWarehouseControl = null;
        private ApplyExWarehouseControl _applyExWarehouseControl = null;
        private ImWarehouseManageControl _imWarehoueManageControl = null;
        private StockManageControl _stockManageControl = null;
        private ExWarehouseManageControl _exWarehouseManageControl = null;
        private ApplyPurchaseControl _applyPurchaseControl = null;
        private PurchaseManageControl _purchaseManageControl = null;
        private ChangePasswordControl _changePasswordControl = null;
        private ApplyManageControl _applyMangeControl = null;
        private RestitutionManageControl _restitutionManageControl = null;

        public ManageMainControl()
        {
            InitializeComponent();
        }

        public SupplierManageControl SupplierManageControl
        {
            get
            {
                if (_supplierManageControl == null)
                    _supplierManageControl = new SupplierManageControl() { Dock = DockStyle.Fill };
                return _supplierManageControl;
            }
            set => _supplierManageControl = value;
        }

        public SpecificationManageControl SpecificationManageControl
        {
            get
            {
                if (_specificationManageControl == null)
                    _specificationManageControl = new SpecificationManageControl() { Dock = DockStyle.Fill };
                return _specificationManageControl;
            }
            set => _specificationManageControl = value;
        }

        public GoodsManagerControl GoodsManageControl
        {
            get
            {
                if (_goodsManageControl == null)
                    _goodsManageControl = new GoodsManagerControl() { Dock = DockStyle.Fill };
                return _goodsManageControl;
            }
            set => _goodsManageControl = value;
        }

        internal ApplyImWarehouseControl ApplyImWarehouseControl
        {
            get
            {
                if (_applyImWarehouseControl == null)
                    _applyImWarehouseControl = new ApplyImWarehouseControl() { Dock = DockStyle.Fill };
                return _applyImWarehouseControl;
            }
            set => _applyImWarehouseControl = value;
        }

        public ApplyExWarehouseControl ApplyExWarehouseControl
        {
            get
            {
                if (_applyExWarehouseControl == null)
                    _applyExWarehouseControl = new ApplyExWarehouseControl() { Dock = DockStyle.Fill };
                ; return _applyExWarehouseControl;
            }
            set => _applyExWarehouseControl = value;
        }

        public ImWarehouseManageControl ImWarehoueManageControl
        {
            get
            {
                if (_imWarehoueManageControl == null)
                    _imWarehoueManageControl = new ImWarehouseManageControl() { Dock = DockStyle.Fill };
                return _imWarehoueManageControl;
            }
            set => _imWarehoueManageControl = value;
        }

        public StockManageControl StockManageControl
        {
            get
            {
                if (_stockManageControl == null)
                    _stockManageControl = new StockManageControl() { Dock = DockStyle.Fill };
                return _stockManageControl;
            }
            set => _stockManageControl = value;
        }

        public ExWarehouseManageControl ExWarehouseManageControl
        {
            get
            {
                if (_exWarehouseManageControl == null)
                    _exWarehouseManageControl = new ExWarehouseManageControl() { Dock = DockStyle.Fill };
                return _exWarehouseManageControl;
            }
            set => _exWarehouseManageControl = value;
        }

        public ApplyPurchaseControl ApplyPurchaseControl
        {
            get
            {
                if (_applyPurchaseControl == null)
                    _applyPurchaseControl = new ApplyPurchaseControl() { Dock = DockStyle.Fill };
                return _applyPurchaseControl;
            }
            set => _applyPurchaseControl = value;
        }
        public PurchaseManageControl PurchaseManageControl
        {
            get
            {
                if (_purchaseManageControl == null)
                    _purchaseManageControl = new PurchaseManageControl() { Dock = DockStyle.Fill };
                return _purchaseManageControl;
            }
            set => _purchaseManageControl = value;
        }

        public ChangePasswordControl ChangePasswordControl
        {
            get
            {
                if (_changePasswordControl == null)
                    _changePasswordControl = new ChangePasswordControl() { Dock = DockStyle.Fill };
                return _changePasswordControl;
            }
            set => _changePasswordControl = value;
        }

        internal ApplyManageControl ApplyMangeControl
        {
            get
            {
                if (_applyMangeControl == null)
                    _applyMangeControl = new ApplyManageControl() { Dock = DockStyle.Fill };
                return _applyMangeControl;
            }
            set => _applyMangeControl = value;
        }

        public RestitutionManageControl RestitutionManageControl
        {
            get
            {
                if (_restitutionManageControl == null)
                    _restitutionManageControl = new RestitutionManageControl() { Dock = DockStyle.Fill };
                return _restitutionManageControl;
            }
            set => _restitutionManageControl = value;
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(SupplierManageControl);
            SupplierManageControl.FreshData();
        }

        private void btnSpecificationManage_Click(object sender, EventArgs e)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(SpecificationManageControl);
            SpecificationManageControl.FreshData();
        }

        private void btnGoods_Click(object sender, EventArgs e)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(GoodsManageControl);
            GoodsManageControl.FreshData();
        }

        private void btnApplyImWarehouse_Click(object sender, EventArgs e)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(ApplyImWarehouseControl);
            ApplyImWarehouseControl.FreshData();
        }

        private void btnApplyExWarehouse_Click(object sender, EventArgs e)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(ApplyExWarehouseControl);
            ApplyExWarehouseControl.FreshData();
        }

        private void btnImWarehouse_Click(object sender, EventArgs e)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(ImWarehoueManageControl);
            ImWarehoueManageControl.FreshData();
        }

        private void btnQueryStock_Click(object sender, EventArgs e)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(StockManageControl);
            StockManageControl.FreshData();
        }

        private void btnExWarehouse_Click(object sender, EventArgs e)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(ExWarehouseManageControl);
            ExWarehouseManageControl.FreshData();
        }

        private void btnApplyPurchase_Click(object sender, EventArgs e)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(ApplyPurchaseControl);
            ApplyPurchaseControl.FreshData();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(PurchaseManageControl);
            PurchaseManageControl.FreshData();
        }

        private void btnPersonInfo_Click(object sender, EventArgs e)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(ChangePasswordControl);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(ApplyMangeControl);
            ApplyMangeControl.FreshData();
        }

        private void btnRestitution_Click(object sender, EventArgs e)
        {
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(RestitutionManageControl);
            RestitutionManageControl.FreshData();
        }
    }
}