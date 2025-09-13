using microsoft.aspnetcore.mvc;
using microsoft.entityframeworkcore;
using dcp_accounts_api.data;
using dcp_accounts_api.models;

namespace dcp_accounts_api.controllers
{
    [route("api/[controller]")]
    [apicontroller]
    public class expendheadcontroller : controllerbase
    {
        private readonly appdbcontext _context;

        public expendheadcontroller(appdbcontext context)
        {
            _context = context;
        }

        [httpget]
        public async task<actionresult<ienumerable<expendhead>>> getexpendheads()
        {
            return await _context.expendheads.tolistasync();
        }

        [httpget("{id}")]
        public async task<actionresult<expendhead>> getexpendhead(int id)
        {
            var item = await _context.expendheads.findasync(id);
            if (item == null) return notfound();
            return item;
        }

        [httppost]
        public async task<actionresult<expendhead>> postexpendhead(expendhead item)
        {
            _context.expendheads.add(item);
            await _context.savechangesasync();
            return createdataction(nameof(getexpendhead), new { id = item.expheadid }, item);
        }

        [httpput("{id}")]
        public async task<iactionresult> putexpendhead(int id, expendhead item)
        {
            if (id != item.expheadid) return badrequest();
            _context.entry(item).state = entitystate.modified;
            await _context.savechangesasync();
            return nocontent();
        }

        [httpdelete("{id}")]
        public async task<iactionresult> deleteexpendhead(int id)
        {
            var item = await _context.expendheads.findasync(id);
            if (item == null) return notfound();
            _context.expendheads.remove(item);
            await _context.savechangesasync();
            return nocontent();
        }
    }
}
